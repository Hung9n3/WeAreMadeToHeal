using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/customer/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseCustomerController<User, TLogic> : ControllerBase where User : BaseEntity where TLogic : IBaseLogicProvider<User>
    {
        #region [ Fields ]
        protected readonly ILogger<BaseCustomerController<User, TLogic>> _logger;
        protected readonly LogicContext _logicContext;
        protected readonly TLogic _logic;
        #endregion

        #region [ CTor ]
        public BaseCustomerController(
            ILogger<BaseCustomerController<User, TLogic>> logger,
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
