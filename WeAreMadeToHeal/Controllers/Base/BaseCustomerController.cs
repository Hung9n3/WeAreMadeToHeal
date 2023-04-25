using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/customer/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseCustomerController<TEntity, TLogic> : ControllerBase where TEntity : BaseEntity where TLogic : IBaseLogicProvider<TEntity>
    {
        #region [ Fields ]
        protected readonly ILogger<BaseCustomerController<TEntity, TLogic>> _logger;
        protected readonly ExcelHandlerService _excelHandlerService;
        protected readonly LogicContext _logicContext;
        protected readonly TLogic _logic;
        #endregion

        #region [ CTor ]
        public BaseCustomerController(
            ILogger<BaseCustomerController<TEntity, TLogic>> logger,
            ExcelHandlerService excelHandlerService,
            LogicContext logicContext,
            TLogic logic)
        {
            this._logger = logger;
            this._excelHandlerService = excelHandlerService;
            this._logicContext = logicContext;
            this._logic = logic;
        }
        #endregion



    }
}
