using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AulaAtecaInteractive
{
    /// <summary>
    /// Class <c>FadeCanvasTransition</c> allows to start a FadeIn / FadeOut Canvas Transition.
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeCanvasTransition : MonoBehaviour
    {
        [Header("Fade Configuration")]
        [SerializeField] private float fadeDuration = 0.61f;

        private CanvasGroup canvasGroup;

        private void Awake()
        {
            if (!TryGetComponent(out canvasGroup))
            {
#if DEBUG
                Debug.LogWarning("Canvas Group Not Found for: " + gameObject.name);
#endif
            }
        }

        #region Fades Call Methods
        /// <summary>
        /// Call the FadeIn transition.
        /// </summary>
        /// <param name="shouldModifyGameObject">If the gameobject requires activation (default True)</param>
        public void StartFadeIn(bool shouldModifyGameObject = true)
        {
            if (shouldModifyGameObject)
                gameObject.SetActive(true);
            StartCoroutine(FadeIn());
        }

        /// <summary>
        /// Call the FadeOut transition
        /// </summary>
        /// <param name="shouldModifyGameObject">If the gameobject requires deactivation (default True)</param>

        public void StartFadeOut(bool shouldModifyGameObject = true)
        {
            StartCoroutine(FadeOut(shouldModifyGameObject));
        }

        #endregion

        #region Fade In/Out Methods;
        private IEnumerator FadeIn()
        {
            float currentTime = 0f;
            float startAlpha = 0f;

            while (currentTime < fadeDuration)
            {
                currentTime += Time.unscaledDeltaTime; // Independiente al TimeScale;
                float alpha = Mathf.Lerp(startAlpha, 1f, currentTime / fadeDuration);
                canvasGroup.alpha = alpha;
                yield return null;
            }

            canvasGroup.interactable = true;
        }

        private IEnumerator FadeOut(bool shouldModifyGameObject)
        {
            canvasGroup.interactable = false;

            float currentTime = 0f;
            float startAlpha = 1f;

            while (currentTime < fadeDuration)
            {
                currentTime += Time.unscaledDeltaTime; // Independiente al TimeScale;
                float alpha = Mathf.Lerp(startAlpha, 0f, currentTime / fadeDuration);
                canvasGroup.alpha = alpha;
                yield return null;
            }

            if (shouldModifyGameObject)
                gameObject.SetActive(false);
        }

        /// <summary>
        /// Instantly Fade In
        /// </summary>
        /// <param name="shouldModifyGameObject">If the gameobject requires activation (default True)</param>
        public void InstantFadeIn(bool shouldModifyGameObject = true)
        {
            if (shouldModifyGameObject)
                gameObject.SetActive(true);
            canvasGroup.alpha = 1;
        }
        #endregion
    }
}