using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Services
{
    public class EntryPointService : IEntryPointService
    {
        private readonly ILoggerAdapter<EntryPointService> _logger;
        private readonly ICapture _capture;
        private readonly IUpload _upload;
        private readonly IUrlStatusChecker _urlStatusChecker;
        private readonly EntryPointSettings _settings;
        private readonly IServiceLocator _serviceScopeFactoryLocator;

        public EntryPointService(ILoggerAdapter<EntryPointService> logger,
            EntryPointSettings settings,
            IUpload upload,
            ICapture capture,
             IServiceLocator serviceScopeFactoryLocator,
            IUrlStatusChecker urlStatusChecker)
        {
            _logger = logger;
            _settings = settings;
            _capture = capture;
            _upload = upload;
            _serviceScopeFactoryLocator = serviceScopeFactoryLocator;
            _urlStatusChecker = urlStatusChecker;
        }

        public async Task ExecuteAsync()
        {
            _logger.LogInformation("{service} running at: {time}", nameof(EntryPointService), DateTimeOffset.Now);
            try
            {
                // capture the image
                _capture.CaptueImage(_settings);

                //check the directory for changes
                //If the directory has a change
                //Take the image 
                //Upload to the server


                // check 1 URL in the message
                //var statusHistory = await _urlStatusChecker.CheckUrlAsync(message, "");
                // record HTTP status / response time 
                // _logger.LogInformation("Record HTTP status ,response time {time}", statusHistory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(EntryPointService)}.{nameof(ExecuteAsync)} threw an exception.");
            }
        }
    }
}