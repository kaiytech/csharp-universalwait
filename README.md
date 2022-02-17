# C# Universal Wait

Pretty much a simple universal wait class, that you can apply to any parameter-less method you wish.

## Usage:
Let's assume we have a method like this
```
bool ImHappy()
{
  if(EveryoneElseIsHappy())
    return true;
  return false;
}
```

Let's wait for me to be happy, but only for 10 seconds.
```
Wait.Until(ImHappy).Is(true);
```

Timeouts are customisable. Let's wait for everyone else in the world to comply for a bit longer.
```
Wait.Until(ImHappy).Is(true, 60);
```

And you can also do the opposite. Let's wait as long as I'm sad (with a 10s timeout):
```
Wait.AsLongAs(ImHappy).Is(false)
```

Failure to meet the condition in the given timestamp will result in an Exception.

...unless we specify otherwise.
```
var happy = Wait.Until(ImHappy).Is(true, throwException: false);
```
Then we can use the return value later on.

