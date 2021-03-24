using StuWare.Data.Migrations;
using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public interface IPanelRepository
    {
        IQueryable<Panel> Panels { get; }

        void CreatePanel(Panel panel);


        void DeletePanel(int panelid);


        Panel GetById(int panelid);

        void UptadePanel(Panel panel);
    }
}
