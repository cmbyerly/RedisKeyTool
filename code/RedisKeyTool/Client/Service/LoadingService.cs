using System;
using System.Threading.Tasks;

namespace RedisKeyTool.Service
{
    /// <summary>
    /// This is the service to bring up the loading window.
    /// </summary>
    public class LoadingService
    {
        /// <summary>
        /// Starts the loading.
        /// </summary>
        public async Task StartLoading()
        {
            if (NotifyStartLoading != null)
            {
                await NotifyStartLoading.Invoke();
            }
        }

        /// <summary>
        /// Occurs when [notify start loading].
        /// </summary>
        public event Func<Task> NotifyStartLoading;

        /// <summary>
        /// Stops the loading.
        /// </summary>
        public async Task StopLoading()
        {
            if (NotifyStopLoading != null)
            {
                await NotifyStopLoading.Invoke();
            }
        }

        /// <summary>
        /// Occurs when [notify stop loading].
        /// </summary>
        public event Func<Task> NotifyStopLoading;
    }
}