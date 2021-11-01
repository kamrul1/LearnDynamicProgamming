# Dynamic Prgamming

### What is this?

This repo, follows though the [Dynamic Programming - Learn to Solve Algorithmic Problems & Coding Challenges](https://www.youtube.com/watch?v=oBt53YbR9Kk)
 tutorial online on Youtube.

This is my source code and learning notes from the course.  The tutorial uses JavaScript, this solution follows along with C#, my language of 
choice.

These examples can be broken into:
- part 1 Memoization
- part 2 Tabulation


### Best approach to the work

As advised in the course, it's best to use a paper to visualise the problem and form a strategy, this si the hardest
part. Writing the algoritham is the easier part.

---


### Example 1 - [Fib (Memoization)](https://youtu.be/oBt53YbR9Kk?t=260)

Use recussion, to go down the tree.

The most efficient approach is to use a dictionary as optional parameter, so as not to repeat already computed 
values. 
```csharp
public Fib(int nthNo, Dictionary<int, int> knowFibValue = null)
{
    this.nthNo = nthNo;

    if (knowFibValue is null)
    {
        knowFibValue = new();
    }

    this.knownFibValue = knowFibValue;

}
```

One gotcha about C# is that as the datatype, not to use int as is typical the case but to use long, because the numbers
do get very long.   

There was a good case to make the class static - this is not a complex function. 
I choose to not do that, as I have found typically, 
when the methods do get complex it's easier to apply SOLID principle to instance classes.

---

## Example 2 - [GridTraveler (Memoization)](https://youtu.be/oBt53YbR9Kk?t=2322)

Again, use recussion, to go down the tree node.

I could have just used a string as key but was being more adventurous so used a class as key

```csharp
public class Coord 
{
    protected readonly int x;
    protected readonly int y;

    public Coord(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object obj)
    {
        var otherCoord = obj as Coord;

        if (otherCoord.x == this.x && otherCoord.y == this.y)
        {
            return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }
}
``` 

Created a dictionary field for key value pairs: 
```csharp        
private readonly Dictionary<Coord, long> knownPairs;
```

Create a new Coord class, with an x and y value, then see if the key matches that which is inside the dictionary.
```csharp
if(knownPairs.TryGetValue(new Coord(x,y), out long value))
{
    return value;
}
```

## Example 2 [CanSum](https://youtu.be/oBt53YbR9Kk?t=4217)

An easy way to solve this is to take the [inverse position](https://youtu.be/oBt53YbR9Kk?t=4445).   This was not obvious to me at the start, I was adding value instead.

## Example 3 [HowSum](https://youtu.be/oBt53YbR9Kk?t=5376)

--TODO





