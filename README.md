# ConsoleRobot

I have a basic working program and some simple example bat files to test.
I haven't used a IoC container, but it was designed with dependency injection in mind to enable easy refactoring for unit testing / mocking.
I was going to include unit tests but ran out of time.

Incidentally, I have a history with toy robots - this is a video of my Son playing with Raspberry-Pi / node.js powered one I built: [https://www.youtube.com/watch?v=CqkG3Uy1cR8](https://www.youtube.com/watch?v=CqkG3Uy1cR8)

## Examples

A post-build event copies the exe into the **example** directory, and double-clicking the **.bat** files in explorer will run them.


## A note on comments

I comment differently to most, but I believe it's an effective way to keep code clean and limit technical debt:

I comment at the end of a line in natural language pseudo-code, with indentation matching the code.
This means the comments aren't intermingled with the code, and both code and pseudo-code can be read separately without context-switching.
Furthermore, deleting, moving, and changing indentation effects both code and comments, keeping them in-line and reducing the build up of technical debt with out of date comments or double editing.

For example:

        public static int[] toVector(this int direction)
        {
            int[] result = new int[] { 0, 0 };                                    // default is the identity vector - the robot will remain stationary

            if(direction.isInRange(0, vectorMap.Length))                          // if the direction is valid ...
            {
                result = vectorMap[direction];                                        // get the corresponding vector array
            }
            return result;                                                        // return either the default or the matching vector
        }


I also have a Gist on an interesting comment toggle I've been using for years, that I've never seen used elsewhere:
[https://gist.github.com/farmerBri/392d089e4bac4511a1f4f6138d2558ec](https://gist.github.com/farmerBri/392d089e4bac4511a1f4f6138d2558ec)

Cheers!