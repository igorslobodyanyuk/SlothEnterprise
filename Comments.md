# ProductApplicationService code issues
* Style inconsistency. It uses multiple ways for calling the required services and returning their results.
* Many similar if statements. This should be replaced with switch expression for better readability.
* Tight coupling. It depends on all the services and on their internal implementation. This would be a nightmare to extend and maintain in future.
* Long method. It contains logic for calling all the services in the various ways.
* Poor testability. If we want to test the ProductApplicationServices, we'll have to inject all the dependend services and count on internal implementation. This would be really hard to test and extend in future and these tests would create more problems then solve.