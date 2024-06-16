namespace final_project_aspdotnet_web_api.Entities
//The keyword "namespace" is used to declare a scope that contains a set of related objects (classes, interfaces, structures, delegates) --> The name of the namespace is like the file location and they are used to organize code into a hierarchical structure and to avoid name conflicts --> In other words, it helps isolate classes and control the scope so that any class declared inside of it does not clash with namespaces in other locations of our program
{
    public class Todos
        //This is where we define our schema for Todos by creating a Class, which is a blueprint for creating objects dynamically --> The "public" keyword is an access modifier and it means that this class (or anything it precedes) is accessible from any other code --> "class Todos { } is the syntax to declare and create a class
    {
        // "{get; set'}" is the property accessor, which defines that the property it comes after (in this first case it refers to the "Id" property) has both a getter (which refers to the ability to READ the value) and a setter (which refers to the ability to WRITE the value) --> Like getters and setters class methods we used in JavaScript Classes
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; //The "string.Empty" is setting a default value to an empty string to avoid null reference errors if no value is given to the Name property when creating the instance object
        public string Description { get; set; } = string.Empty;
    }
}
