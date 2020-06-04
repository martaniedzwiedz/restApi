using Microsoft.AspNetCore.Mvc;

namespace project_test.Controllers
{
    public class BaseController<T> : ControllerBase
    {
        protected T _service;

        public BaseController(T service)
        {
            _service = service;
        }
    }
}