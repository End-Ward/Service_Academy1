using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service_Academy1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Service_Academy1.Controllers
{
    public class ProgramListController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action method for ProgramList that filters by Agenda
        public IActionResult ProgramList(string agenda)
        {
            // Define a dictionary to hold agenda titles and their detailed descriptions
            var programDetails = new Dictionary<string, (string Title, string Description)>
          {
                  { "BISIG", ("BatStateU Inclusive Social Innovation for Regional Growth (BISIG)", "The BatStateU Inclusive Social Innovation for Regional Growth (BISIG) is a program designed to develop innovative solutions—such as new concepts, processes, products, or organizational changes—that enhance the well-being of families and communities. It focuses on addressing socio-economic and environmental challenges by fostering a collaborative policy framework.") },

                  { "LEAF", ("Livelihood and Other Entrepreneurship related on Agri-Fisheries (LEAF)", "The Livelihood and Entrepreneurship related to Agri-Fisheries (LEAF) program aims to identify and develop potential extension programs that provide livelihood and entrepreneurship opportunities in the agri-fisheries sector. Its goal is to reduce poverty and inequality by creating jobs, generating income, and moving vulnerable households toward sustainable livelihoods and economic stability.") },

                  { "Environment", ("Environment and Natural Resources Conservation, Protection and Rehabilitation", "The Environment and Natural Resources Conservation, Protection and Rehabilitation program aims to promote the conservation, protection, and rehabilitation of the environment and natural resources.") },

                  { "SAEI", ("Smart Analytics for Engineering Innovation", "The Smart Analytics for Engineering Innovation program aims to promote research-based extension to help various data users effectively utilize data for informed decision-making.") },

                  { "BINADI", ("Adopt-A-Municipality / Social Development Through BINADI Implementation", "The Adopt-A-Municipality program is designed to create, implement, and assess high-impact, research-based community development projects.") },

                  { "Outreach", ("Community Outreach", "The Community Outreach agenda seeks to involve University stakeholders in humanitarian activities and public service.") },

                  { "TVET", ("Technical-Vocational Education And Training (TVET)", "The TVET Program aims to equip the economy with skilled and capable workers.") },

                  { "TTAU", ("Technology Transfer, And Adoption / Utilization", "This agenda focuses on supporting faculty and students in developing pathways for research-based technology transfer.") },

                  { "TAAS", ("Technical Assistance And Advisory Services", "This initiative aims to identify strategies to enhance the productivity of local government units, small and medium enterprises, and educational institutions.") },

                  { "PESODEV", ("Parents' Empowerment Thru Social Development (PESODEV)", "The PESODEV program aims to integrate a gender perspective into the curriculum and operations of the University.") },

                  { "GAD", ("Gender And Development", "The Gender And Development program aims to integrate a gender perspective into the curriculum and research of the University.") },

                  { "DisasaterRisk", ("Disaster Risk Reduction And Management And Disaster Preparedness And Response", "The DRRM program aims to foster a safe and secure environment for individuals and communities.") }
              };

            // Retrieve the title and description based on the selected agenda
            (string Title, string Description) selectedProgramDetail;

            if (programDetails.TryGetValue(agenda, out selectedProgramDetail))
            {
                ViewBag.AgendaTitle = selectedProgramDetail.Title; // Set the agenda title
                ViewBag.AgendaDescription = selectedProgramDetail.Description; // Set the agenda description
            }
            else
            {
                ViewBag.AgendaTitle = "Default Title"; // Fallback title
                ViewBag.AgendaDescription = "Default description for all agendas."; // Fallback description
            }

            // Fetch programs from the database based on the agenda
            var programsQuery = string.IsNullOrEmpty(agenda)
                ? _context.Programs.Include(p => p.ProgramManagement)
                : _context.Programs.Where(p => p.Agenda == agenda).Include(p => p.ProgramManagement);

            // Convert the query to a list
            var programs = programsQuery.ToList();

            // Check if there are no programs for the selected agenda
            if (!programs.Any())
            {
                return RedirectToAction("NoPrograms");
            }

            return View(programs);
        }

        // Action method for the NoPrograms page
        public IActionResult NoPrograms()
        {
            return View();
        }

    }
}
