using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

public static class SpriteUtil {
    /// <summary>Get first Sprite from an AnimationClip.</summary>
    public static Sprite GetFirst(AnimationClip clip) {
        Assert.IsNotNull(clip, "AnimationClip can't be null.");

        foreach (EditorCurveBinding curveBinding in AnimationUtility.GetObjectReferenceCurveBindings(clip)) {
            ObjectReferenceKeyframe[] keyframes = AnimationUtility.GetObjectReferenceCurve(clip, curveBinding);

            if (keyframes.Length == 0) {
                continue;
            }

            return keyframes[0].value as Sprite;
        }

        return null;
    }
}
