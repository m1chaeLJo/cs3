using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 实现镂空效果的Mask组件
/// </summary>
public class HollowOutMask : MaskableGraphic, ICanvasRaycastFilter
{
    [SerializeField]
    private RectTransform _target;

    private Vector3 _targetMin = Vector3.zero;
    private Vector3 _targetMax = Vector3.zero;

    private bool _canRefresh = true;
    private Transform _cacheTrans = null;

    /// <summary>
    /// 设置镂空的目标
    /// </summary>
    public void SetTarget(RectTransform target)
    {
        _canRefresh = true;
        _target = target;
        _RefreshView();
    }

    private void _SetTarget(Vector3 tarMin, Vector3 tarMax)
    {
        if (tarMin == _targetMin && tarMax == _targetMax)
            return;
        _targetMin = tarMin;
        _targetMax = tarMax;
        SetAllDirty();
    }

    private void _RefreshView()
    {
        if (!_canRefresh) return;
        _canRefresh = false;

        if (null == _target)
        {
            _SetTarget(Vector3.zero, Vector3.zero);
            SetAllDirty();
        }
        else
        {
            Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(_cacheTrans, _target);
            _SetTarget(bounds.min, bounds.max);
        }
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        if (_targetMin == Vector3.zero && _targetMax == Vector3.zero)
        {
            base.OnPopulateMesh(vh);
            return;
        }
        vh.Clear();

        // 填充顶点
        UIVertex vert = UIVertex.simpleVert;
        vert.color = color;

        Vector2 selfPiovt = rectTransform.pivot;
        Rect selfRect = rectTransform.rect;
        float outerLx = -selfPiovt.x * selfRect.width;
        float outerBy = -selfPiovt.y * selfRect.height;
        float outerRx = (1 - selfPiovt.x) * selfRect.width;
        float outerTy = (1 - selfPiovt.y) * selfRect.height;
        // 0 - Outer:LT
        vert.position = new Vector3(outerLx, outerTy);
        vh.AddVert(vert);
        // 1 - Outer:RT
        vert.position = new Vector3(outerRx, outerTy);
        vh.AddVert(vert);
        // 2 - Outer:RB
        vert.position = new Vector3(outerRx, outerBy);
        vh.AddVert(vert);
        // 3 - Outer:LB
        vert.position = new Vector3(outerLx, outerBy);
        vh.AddVert(vert);

        // 4 - Inner:LT
        vert.position = new Vector3(_targetMin.x, _targetMax.y);
        vh.AddVert(vert);
        // 5 - Inner:RT
        vert.position = new Vector3(_targetMax.x, _targetMax.y);
        vh.AddVert(vert);
        // 6 - Inner:RB
        vert.position = new Vector3(_targetMax.x, _targetMin.y);
        vh.AddVert(vert);
        // 7 - Inner:LB
        vert.position = new Vector3(_targetMin.x, _targetMin.y);
        vh.AddVert(vert);

        // 设定三角形
        vh.AddTriangle(4, 0, 1);
        vh.AddTriangle(4, 1, 5);
        vh.AddTriangle(5, 1, 2);
        vh.AddTriangle(5, 2, 6);
        vh.AddTriangle(6, 2, 3);
        vh.AddTriangle(6, 3, 7);
        vh.AddTriangle(7, 3, 0);
        vh.AddTriangle(7, 0, 4);
    }

    bool ICanvasRaycastFilter.IsRaycastLocationValid(Vector2 screenPos, Camera eventCamera)
    {
        if (null == _target) return true;
        // 将目标对象范围内的事件镂空（使其穿过）
        return !RectTransformUtility.RectangleContainsScreenPoint(_target, screenPos, eventCamera);
    }

    protected override void Awake()
    {
        base.Awake();
        _cacheTrans = GetComponent<RectTransform>();
    }

#if UNITY_EDITOR
    void Update()
    {
        _canRefresh = true;
        _RefreshView();
    }
#endif
}