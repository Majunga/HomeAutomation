using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DeviceService<T> where T : DeviceEntity
    {
        private readonly string _path = "/api/device";
        public async Task<DeviceEntity> Create(T model)
        {
            var data = await new RestApi("", _path).Post<DeviceEntity>(model);

            if(data.Item1)
            {
                return data.Item2;
            }
            else
            {
                return null;
            }
        }
    }
}
