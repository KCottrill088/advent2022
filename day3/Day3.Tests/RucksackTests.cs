using System.ComponentModel;
using Xunit;

namespace Day3.Tests;

public class RucksackTests
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", "vJrwpWtwJgWr", "hcsFMMfFFhFp")]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "jqHRNqRjqzjGDLGL", "rsFMfFZSrLrFZsSL")]
    [InlineData("PmmdzqPrVvPwwTWBwg", "PmmdzqPrV", "vPwwTWBwg")]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "wMqvLMZHhHMvwLH", "jbvcjnnSBnvTQFn")]
    [InlineData("ttgJtRGJQctTZtZT", "ttgJtRGJ", "QctTZtZT")]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", "CrZsJsPPZsGz", "wwsLwLmpwMDw")]
    public void CompartmentTests(string items, string expectedCompartment1, string expectedCompartment2)
    {
        var rucksack = new Rucksack(items);
        
        Assert.Equal(expectedCompartment1, rucksack.Compartment1);
        Assert.Equal(expectedCompartment2, rucksack.Compartment2);
    }

    [Theory]
    [InlineData("p", "vJrwpWtwJgWrhcsFMMfFFhFp")]
    [InlineData("L", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL")]
    [InlineData("P", "PmmdzqPrVvPwwTWBwg")]
    [InlineData("v", "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn")]
    [InlineData("t", "ttgJtRGJQctTZtZT")]
    [InlineData("s", "CrZsJsPPZsGzwwsLwLmpwMDw")]
    public void ItemInBothTests(string expectedItemInBoth, string items)
    {
        var rucksack = new Rucksack(items);

        Assert.Equal(expectedItemInBoth, rucksack.ItemInBoth().ToString());
    }

    [Theory]
    [InlineData('p', 16)]
    [InlineData('L', 38)]
    [InlineData('P', 42)]
    [InlineData('v', 22)]
    [InlineData('t', 20)]
    [InlineData('s', 19)]
    public void PriorityTests(char item, int expectedPriority)
    {
        var actualPriority = Rucksack.Priority(item);
        
        Assert.Equal(expectedPriority, actualPriority);
    }
}