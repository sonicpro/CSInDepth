namespace DelegateDemo
{
    public delegate string FirstDelegate(int x);

    // This class contains an instance method with the signature of FirstDelegate.
    // it also defines a bunch if FirstDelegate instances on DelegateInstanceCreationDemo function.

    // Notice wrapping the private methods as the delegate instances, so the eventual caller might call them
    // through the delegate instance exposed from this class.
    class DelegateDefinition
    {
        private string Name { get; }

        public DelegateDefinition(string name)
        {
            Name = name;
        }

        private string OwnInstanceMethod(int x)
        {
            return $"{Name}: {x}";
        }

        private static string StaticMethod(int x)
        {
            return $"Static method: {x}";
        }

        public (FirstDelegate, FirstDelegate) DelegateInstanceCreationDemo(ClassWithTheStaticAndInstanceMethod theOtherClassInstance)
        {
            // 1. FirstDelegate instance created by passing an instance methos if "this" class.
            FirstDelegate d1 = new FirstDelegate(this.OwnInstanceMethod);

            // 2. FirstDelegate instance created by passing the other class instance method.
            // "TheOtherClassInstanceMethod" must be visible at the moment of creation, so it is public.
            FirstDelegate d2 = new FirstDelegate(theOtherClassInstance.TheOtherClassInstanceMethod);

            // 3. FirstDelegateInstance created by passing this class static method.
            FirstDelegate d3 = new FirstDelegate(StaticMethod);

            // 4. FirstDelegate instance created by passing the other class static method.
            // "StaticMethod" must be visible at the moment of creation hence it is public in ClassWithTheStaticAndInstanceMethod.
            FirstDelegate d4 = new FirstDelegate(ClassWithTheStaticAndInstanceMethod.TheOtherClassStaticMethod);

            return (d1, d3);
        }
    }
}
