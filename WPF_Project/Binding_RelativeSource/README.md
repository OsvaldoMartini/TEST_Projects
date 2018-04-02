Binding RelativeSource 

Types of Binding
StaticResources, DynamicResources and RelativeSource 

I will expose the use cases of the RelativeSources in WPF.
A rectangle that we want that its height is always equal to its width, a square let's say. We can do this using the element name
Um retângulo que queremos que sua altura seja sempre igual a sua largura, um quadrado digamos. Nós podemos fazer isso usando o nome do elemento

The RelativeSource is a markup extension that is used in particular binding cases when we try to:

1- bind a property of a given object to another property of the object itself, 

2- when we try to bind a property of a object to another one of its relative parents, 

3- when binding a dependency property value to a piece of XAML in case of custom control development 

4- 	in case of using a differential of a series of a bound data. 

All of those situations are expressed as relative source modes.