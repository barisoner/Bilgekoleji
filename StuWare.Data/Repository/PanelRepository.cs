using StuWare.Data.Migrations;
using StuWare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StuWare.Data.Repository
{
    public class PanelRepository : IPanelRepository
    {
        private StuWareContext _context;

        public PanelRepository(StuWareContext context)
        {
            _context = context;
        }

        public IQueryable<Panel> Panels => _context.Panel;

        public void CreatePanel(Panel panel)
        {
            _context.Panel.Add(panel);
            _context.SaveChanges();
        }

        public void DeletePanel(int panelid)
        {
            var panel = GetById(panelid);

            if (panel != null)
            {
                _context.Panel.Remove(panel);
                _context.SaveChanges();
            }
        }

        public Panel GetById(int panelid)
        {
            return _context.Panel.FirstOrDefault(i => i.ID == panelid);
        }

        public void UptadePanel(Panel panel)
        {
            _context.Panel.Update(panel);
            _context.SaveChanges();
        }
    }
}
