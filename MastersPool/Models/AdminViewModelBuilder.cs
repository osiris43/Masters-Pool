using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MastersPool.Services.Interfaces;
using MastersPool.Core;

namespace MastersPool.Models
{
    public class AdminViewModelBuilder
    {
        public AdminViewModelBuilder(IConfigurationService cs, IGolferService gs)
        {
            this.configService = cs;
            this.golferService = gs;
        }

        public AdminViewModel Build()
        {
            AdminViewModel viewModel = new AdminViewModel {GolferSections = new List<GolferSectionViewModel>()};
            int year = Convert.ToInt32(configService.GetConfigurationByKey("CurrentYear").ConfigValue);
            viewModel.CurrentYear = year;

            List<Golfer> golfers = this.golferService.GetAllGolfers();
            List<MastersParticipant> currentPlayers = golferService.GetMastersParticipantsByYear(year);

            this.RemoveParticipantsFromUnassigned(golfers, currentPlayers);
            golfers.Sort();
            GolferSectionViewModel section = new GolferSectionViewModel
            {
                Golfers = golfers,
                SectionHeader = "Unassigned Golfers"
            };
            viewModel.GolferSections.Add(section);
            viewModel.GolferSections.Add(this.BuildParticipantSection(currentPlayers, 7));
            viewModel.GolferSections.Add(this.BuildParticipantSection(currentPlayers, 5));
            viewModel.GolferSections.Add(this.BuildParticipantSection(currentPlayers, 4));
            viewModel.GolferSections.Add(this.BuildParticipantSection(currentPlayers, 3));
            viewModel.GolferSections.Add(this.BuildParticipantSection(currentPlayers, 2));
            viewModel.GolferSections.Add(this.BuildParticipantSection(currentPlayers, 1));

            return viewModel;
        }

        private GolferSectionViewModel BuildParticipantSection(
            List<MastersParticipant> currentPlayers, int moneyGroup)
        {
            if (0 == currentPlayers.Count)
            {
                return new GolferSectionViewModel
                           {
                               Golfers = new List<Golfer>(), 
                               SectionHeader = String.Format("${0} Group", moneyGroup)
                           };
            }

            var query = from cp
                            in currentPlayers
                        where cp.MoneyGroup == moneyGroup
                        select cp.Golfer;


            return new GolferSectionViewModel
                       {
                           Golfers = query.ToList(),
                           SectionHeader = String.Format("${0} Group", moneyGroup)
                       };
        }

        private void RemoveParticipantsFromUnassigned(List<Golfer> unassigned, 
            List<MastersParticipant> participants)
        {
            foreach(MastersParticipant mp in participants)
            {
                if(unassigned.Exists(g => g.Id == mp.GolferId))
                {
                    unassigned.Remove(unassigned.Single(golf => golf.Id == mp.GolferId));
                }
            }
        }
        private IConfigurationService configService = null;
        private IGolferService golferService = null;
    }
}
