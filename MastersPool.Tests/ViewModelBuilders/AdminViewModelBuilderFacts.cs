using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using MastersPool.Core;
using MastersPool.Services.Interfaces;
using Rhino.Mocks;
using MastersPool.Models;

namespace MastersPool.Tests.ViewModelBuilders
{
    public class AdminViewModelBuilderFacts
    {
        [Fact]
        public void ShouldRemoveParticipantsFromUnassigned()
        {
            List<Golfer> golfers = new List<Golfer>();
            golfers.Add(new Golfer { FirstName = "Brett", LastName = "Bim", Id = 1});
            List<MastersParticipant> participants = new List<MastersParticipant>();
            participants.Add(new MastersParticipant {Golfer = golfers[0], GolferId = golfers[0].Id, MoneyGroup = 7});
            this.InitServices(golfers, participants);

            AdminViewModelBuilder builder = new AdminViewModelBuilder(configService, golferService);
            AdminViewModel viewModel = builder.Build();

            Assert.Equal(0, viewModel.GolferSections[0].Golfers.Count);
            Assert.Equal(1, viewModel.GolferSections[1].Golfers.Count);
        }

        [Fact]
        public void ShouldBuildCurrentYear()
        {
            this.InitServices(null, null);

            AdminViewModelBuilder builder = new AdminViewModelBuilder(configService, golferService);

            AdminViewModel viewModel = builder.Build();

            Assert.Equal(viewModel.CurrentYear, 2009);

        }

        [Fact]
        public void ShouldLoadUnassignedGolfers()
        {
            List<Golfer> golfers = new List<Golfer>();
            golfers.Add(new Golfer { FirstName = "Brett", LastName = "Bim" });
            this.InitServices(golfers, null);
            AdminViewModelBuilder builder = new AdminViewModelBuilder(configService, golferService);
            AdminViewModel viewModel = builder.Build();

            Assert.Equal(viewModel.GolferSections[0].SectionHeader, "Unassigned Golfers");
            Assert.Equal(viewModel.GolferSections[0].Golfers.Count, 1);
        }

        private void InitServices(List<Golfer> unassigned, List<MastersParticipant> participants)
        {
            if(null == unassigned)
            {
                unassigned = new List<Golfer>();
            }

            if(null == participants)
            {
                participants = new List<MastersParticipant>();
            }
            golferService = MockRepository.GenerateStub<IGolferService>();
            configService = MockRepository.GenerateStub<IConfigurationService>();

            golferService.Stub(gs => gs.GetAllGolfers()).Return(unassigned);
            golferService.Stub(gs => gs.GetMastersParticipantsByYear(2009)).Return(participants);
            configService.Stub(cs => cs.GetConfigurationByKey("CurrentYear"))
                .Return(new MastersConfiguration { ConfigKey = "CurrentYear", ConfigValue = "2009" });

        }
        private IGolferService golferService = null;
        private IConfigurationService configService = null;
    }
}
