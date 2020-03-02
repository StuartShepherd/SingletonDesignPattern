# Singleton Example
Singleton is a creational design pattern that lets you ensure that a class has only one instance, while providing a global access point to this instance.

## Usage examples
A lot of developers consider the Singleton pattern an antipattern. That’s why its usage is on the decline in C# code.

## Identification
Singleton can be recognized by a static creation method, which returns the same cached object.

It’s pretty easy to implement a sloppy Singleton. You just need to hide constructor and implement a static creation method.

The same class behaves incorrectly in a multithreaded environment. Multiple threads can call the creation method simultaneously and get several instances of Singleton class.

To fix the problem, you have to synchronize threads during the first creation of the Singleton object.

## Getting Started

### Prerequisites

[.NET Core 3.1 SDK or later](https://dotnet.microsoft.com/download/dotnet-core/3.1)