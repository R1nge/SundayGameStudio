using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Task_1.Scripts
{
    public class ImageLoader
    {
        public async UniTask<Texture> GetTexture(int index)
        {
            UnityWebRequest request = await UnityWebRequestTexture.
                GetTexture($"https://data.ikppbb.com/test-task-unity-data/pics/{index}.jpg").
                SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                request.Dispose();
                return null;
            }

            return DownloadHandlerTexture.GetContent(request);
        }
    }
}