﻿using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal
{
    public class UserController : BaseAdminController<User, IUserLogic>
    {
        public UserController(ILogger<BaseAdminController<User, IUserLogic>> logger, LogicContext logicContext, IUserLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
