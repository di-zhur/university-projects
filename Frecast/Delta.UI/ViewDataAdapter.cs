using Delta.DataAccess;
using Delta.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Delta.UI
{
    public class ViewDataAdapter
    {
        private IUnitOfWork _unitOfWork;

        public ViewDataAdapter()
        {
            _unitOfWork = DependenceContainer.GetDependenceContainer.Resolve<IUnitOfWork>();
        }

        public List<FrecastView> GetFrecastView()
        {
            var frecast = _unitOfWork.FrecastRepository.Get();
            var state = _unitOfWork.FrecastStateRepository.Get();
            return frecast.Select(o => new FrecastView()
            {
                Id = o.Id,
                Date = o.Date.Value,
                Name = o.Name,
                Owner = o.Owner,
                Description = o.Description,
                State = state.FirstOrDefault(e => e.Id == o.FrecastStateId)?.Name
            })
            .OrderByDescending(ord => ord.Date)
            .ToList();
        }

        public FrecastValue GetFrecastDataView(Guid frecastId)
        {
            var data = _unitOfWork.FrecastDataRepository.Get()
                .AsParallel()
                .FirstOrDefault(o => o.FrecastId == frecastId)?.Data;

            if (data != null)
                return JsonConvert.DeserializeObject<FrecastValue>(data);

            return null;
        }

        public FrecastValue GetFrecastResultView(Guid frecastId)
        {
            var data = _unitOfWork.FrecastResultRepository.Get()
                .AsParallel()
                .FirstOrDefault(o => o.FrecastId == frecastId)?.Result;

            if (data != null)
                return JsonConvert.DeserializeObject<FrecastValue>(data);

            return null;
        }
    }
}
