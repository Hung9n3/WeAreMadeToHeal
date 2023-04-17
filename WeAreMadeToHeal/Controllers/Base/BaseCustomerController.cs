using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal
{
    [ApiController]
    [Route("api/v{version:apiVersion}/customer/[controller]")]
    [ApiVersion("1.0")]
    public abstract class BaseCustomerController<T, TLogic> : ControllerBase where T : BaseEntity where TLogic : IBaseLogicProvider<T>
    {
        #region [ Fields ]
        protected readonly ILogger<BaseCustomerController<T, TLogic>> _logger;
        protected readonly LogicContext _logicContext;
        protected readonly TLogic _logic;
        #endregion

        #region [ CTor ]
        public BaseCustomerController(
            ILogger<BaseCustomerController<T, TLogic>> logger,
            LogicContext logicContext,
            TLogic logic)
        {
            this._logger = logger;
            this._logicContext = logicContext;
            _logic = logic;
        }
        #endregion

        

    }
}
