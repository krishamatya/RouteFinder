# Guestlogix Take Home Test - Backend

At Guestlogix we feel that putting developers on the spot with advanced algorithmic puzzles doesn’t exactly highlight one’s true skillset. The intention of this assessment is to see how you approach and tackle a problem in the real world, not quivering in front of a whiteboard.

### What is the test?

You will be building an endpoint that allows users to search a data set. Included in this repository is a set of Airport, Airline, and Route data. Your task is to create models to represent, relate and ultimately expose the data to a GET endpoint. Users of the API will be able to search for routes given an origin and destination.

### User Stories (Requirements)

- As a user I can make a GET request to an endpoint with an `origin` and `destination` query parameter, and receive back the shortest route between the two, as an array of connecting flights. A shortest route is defined as the route with the fewest connections. If there are mulitple routes with the same number of connections, you may choose any of them. 
- As a user I am provided meaningful feedback should no route exist between the airports.
- As a user I am provided meaningful feedback if an error occurred with my request.

> NOTE: THE SHORTEST PATH FUNCTIONALITY MAY NOT RELY ON AN EXTERNAL LIBRARY. YOU MUST DEVELOP THIS ON YOUR OWN.

### Testing

Within the `data` folder you will find two subdirectories, `test` and `full`. `test` offers a small subset of the data found in `full` which you may use when developing your solution. Your final solution however must be performant with the `full` set.

Some test cases to consider on the `test` data set.

| Origin | Destination | Expected Result          |
|--------|-------------|--------------------------|
| YYZ    | JFK         | YYZ -> JFK               |
| YYZ    | YVR         | YYZ -> JFK -> LAX -> YVR |
| YYZ    | ORD         | No Route                 |
| XXX    | ORD         | Invalid Origin           |
| ORD    | XXX         | Invalid Destination      |

### Getting Started

For this test you can use any technology you want... seriously. Node.js? Do it. .NET? Send it. PHP? That still exists? Basically, the point is, use whatever you want, really, no need to try and impress us with a new tech if you aren’t familiar with it, use what you like, anyone can learn a new framework. The only downside is because we want to leave this up to you, we can’t really boilerplate the build steps and such for you, so that adds a little bit of time for you... sorry.

### Hosting

While we're still interested in cloning the repository, and running the solution local as part of our evaluation, sometimes we run into a snag. To circumvent this it's recommended you also prepare a hosted version and provide us the link.

### Submitting

1. Fork this repository and provide your solution.
2. Run through it one last time to make sure it works!
3. Edit SUBMISSION.md to include instructions on how to run the application

### Questions

If you have any questions during the challenge feel free to open an issue on this repo and ask it.
