# ExampleCode-WeaponGenerator
Basic system to create modules for weapons, that can be then generated with various configurations of said modules.

Consists of few ScriptableObject classes, connected by an inheritance from an abstract class that serves as an interface for the generator, while providing serialization in the Unity inspector.
Weapon class contains the module slots and stats along with a constructor that takes an array of modules and processes them.
WeaponGenerator is a simple tester script that generates few Weapons on Start().
