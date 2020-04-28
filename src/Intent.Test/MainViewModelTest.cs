// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModelTest.cs" company="Watson Laboratory">
//   Copyright © 2020 Watson Laboratory
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Intent.Models;
using Intent.ViewModels;
using Moq;
using Xunit;

namespace Intent.Test
{
    public class MainViewModelTest
    {
        private readonly Mock<IIntentionRepository> intentionRepository = new Mock<IIntentionRepository>();

        [Fact]
        public void AddCommand_AddsIntentionToRepository()
        {
            // Arrange
            var uut = new MainViewModel(this.intentionRepository.Object);

            // Act
            uut.Add();

            // Assert
            this.intentionRepository.Verify(o => o.TryAddIntention(It.IsAny<string>()), Times.Once);
        }
    }
}