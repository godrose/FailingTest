﻿using FluentAssertions;
using LogoFX.Client.Mvvm.ViewModel;
using LogoFX.Core;
using Xunit;

namespace FailingTest
{
    public class ThisFeatureShouldBeGreen : WrappingCollectionTestsBase
    {
        [Fact]
        public void
            WhenCollectionIsCreatedWithRangeAndSingleItemAndSourceIsCleared_ThenSingleNotificationIsRaisedWithAllWrappers
            ()
        {
            var source = new RangeObservableCollection<object>();
            var items = new[] { new object() };
            var numberOfTimes = 0;

            var collection = new WrappingCollection(isBulk: true)
            {
                FactoryMethod = o => o
            };
            collection.AddSource(source);
            source.AddRange(items);
            collection.CollectionChanged += (sender, args) =>
            {
                args.OldItems.Should().BeEquivalentTo(items);
                numberOfTimes++;
                numberOfTimes.Should().Be(1);
            };
            source.Clear();
        }
    }
}
