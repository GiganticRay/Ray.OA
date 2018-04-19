using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ray.OA.Model;

namespace Ray.OA.BLL
{
    public class OAOrderInfoService : BaseService<OAOrderInfo>
    {
        public override void SetCurrentDal()
        {
            CurrentDal = dbSession.GetOrderInfoDal;
        }
    }
}
