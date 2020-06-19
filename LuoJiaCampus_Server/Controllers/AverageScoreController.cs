using Microsoft.AspNetCore.Mvc;
using LuoJiaCampus_Server.Models;
using Microsoft.AspNetCore.Authorization;

namespace LuoJiaCampus_Server.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AverageScoreController: ControllerBase {
        
        private readonly ServerDBContext db;

        public AverageScoreController(ServerDBContext context) {
            db = context;
        }
        public static float queryAverageScore(string courseName) {
            return 0;
        }

    }

    

    
}
