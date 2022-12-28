
//using AutoMapper;
//using Docusign.Integration;
//using Docusign.Integration.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Serilog;
//using System.Text;

//namespace Duffnization.API.Controllers
//{
//    [Route("api/[controller]")]
//    [Authorize]
//    public class SignController : Controller
//    {
//        // -- TXT (Text), RAD (Radio), CHK (Check), NAM(Name), CMP (Company)
//        private const string ALLOWED_TYPES = "TXT,RAD,CHK,NAM,CMP";


//        private readonly IMapper _mapper;
//        private readonly RequestSignQueueService _requestSignQueueService;
//        private readonly IDocusignAPI _docuSignAPI;
//        private readonly SystemClientService _systemClientService;
//        private readonly IConfiguration _config;

//        public SignController(IMapper mapper, IDocusignAPI docuSignAPI, RequestSignQueueService requestSignQueueService, SystemClientService systemClientService, IConfiguration configuration)
//        {
//            _mapper = mapper;
//            _requestSignQueueService = requestSignQueueService;
//            _systemClientService = systemClientService;
//            _docuSignAPI = docuSignAPI;
//            _config = configuration;
//        }

//        [HttpPost("RequestSign")]
//        public IActionResult RequestSign([FromBody] RequestSignModel model)
//        {
//            try
//            {
//                string validationMessage = ValidateRequestSign(model);

//                if (validationMessage.Length > 0)
//                {
//                    Log.Warning(validationMessage);
//                    return BadRequest(validationMessage);
//                }

//                var entity = _mapper.Map<RequestSignQueue>(model);
//                entity.StatusId = Domain.Enums.EnumRequestSignQueueStatus.Pending;

//                _requestSignQueueService.Insert(entity);

//            }
//            catch (Exception ex)
//            {
//                Log.Error(ex, "Erro desconhecido");
//                throw;
//            }

//            return Ok();
//        }

//        private string ValidateRequestSign(RequestSignModel model)
//        {
//            string message = string.Empty;

//            var systemClient = _systemClientService.GetByID(model.SystemClientId);
//            if (systemClient == null)
//            {
//                message = $"System Client {model.SystemClientId} not found" + System.Environment.NewLine;

//            }

//            // -- TXT (Text), RAD (Radio), CHK (Check), NAM(Name), CMP (Company)
//            if (model.Tabs.Any(x => !ALLOWED_TYPES.Contains(x.Type)))
//            {
//                message += $"Only types {ALLOWED_TYPES} is allowed";
//            }

//            return message;
//        }

//        [HttpPost("GetStatus")]
//        public IActionResult GetDocumentStatus(int systemClientId, string externalId)
//        {
//            try
//            {
//                var requestSignQueue = _requestSignQueueService.Get(x => x.SystemClientId == systemClientId && x.ExternalId == externalId).OrderByDescending(x => x.CreateDate).FirstOrDefault();
//                var currentStatus = _docuSignAPI.GetDocumentStatus(requestSignQueue.EnvelopeId.ToString());

//                return Json(new { EnvelopId = requestSignQueue.EnvelopeId, Status = currentStatus });
//            }
//            catch (Exception ex)
//            {
//                Log.Logger.Error(ex, "Erro ao obter status do documento");
//                throw;
//            }

//        }

//        [HttpPost("DownloadDocument")]
//        public IActionResult DownloadDocument(int systemClientId, string externalId)
//        {
//            try
//            {
//                var requestSignQueue = _requestSignQueueService.Get(x => x.SystemClientId == systemClientId && x.ExternalId == externalId).OrderByDescending(x => x.CreateDate).FirstOrDefault();
//                return Json(_docuSignAPI.DownloadDocument(requestSignQueue.EnvelopeId.ToString()));
//            }
//            catch (Exception ex)
//            {
//                Log.Logger.Error(ex, "Erro ao efetuar o download");
//                throw;
//            }
//        }



//    }
//}
