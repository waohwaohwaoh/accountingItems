using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DTO;
using WebApplication1.DAL;

namespace WebApplication1.Models
{
    public class Position
    {
        public int positionId { get; set; }
        public string positionName { get; set; }
        public List<Position> GetAll()
        {
            List<PositionDTO> positionsDTOList = new PositionRepository().SelectAll();
            if (positionsDTOList == null)
                return null;
            List<Position> positionsModelsList = new List<Position>();
            foreach (var i in positionsDTOList)
            {
                positionsModelsList.Add(new Position
                {
                    positionId = i.positionId,
                    positionName = i.positionName
                });
            }
            return positionsModelsList;
        }
        public List<Position> GetByUserId(Guid _id)
        {
            List<PositionDTO> positionsDTOList = new PositionRepository().SelectByUserId(_id);
            if (positionsDTOList == null)
                return null;
            List<Position> positionsModelsList = new List<Position>();
            foreach (var i in positionsDTOList)
            {
                positionsModelsList.Add(new Position
                {
                    positionId = i.positionId,
                    positionName = i.positionName
                });
            }
            return positionsModelsList;
        }
    }
}