namespace Autofac.Extensions.TypedFactories.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;

    public static class GenericTypeParameterBuilderExtensions
    {
        public static void ApplyGenericParameterConstraints(
            this GenericTypeParameterBuilder genericTypeParameterBuilder, 
            params Type[] constraints)
        {
            if (genericTypeParameterBuilder == null)
                throw new ArgumentNullException(nameof(genericTypeParameterBuilder));

            var interfaceConstraints = new List<Type>();

            foreach (Type constraint in constraints)
            {
                if (constraint.GetTypeInfo().IsInterface)
                {
                    interfaceConstraints.Add(constraint);
                }
                else
                {
                    genericTypeParameterBuilder.SetBaseTypeConstraint(constraint);
                }
            }

            genericTypeParameterBuilder.SetInterfaceConstraints(interfaceConstraints.ToArray());
        }

        public static void ApplyGenericParameterAttributes(
            this GenericTypeParameterBuilder genericTypeParameterBuilder, 
            GenericParameterAttributes genericParameterAttributes)
        {
            IEnumerable<GenericParameterAttributes> allGenericParameterAttributes = Enum.GetValues(typeof(GenericParameterAttributes)).Cast<GenericParameterAttributes>();

            var attributes = GenericParameterAttributes.None;

            foreach (GenericParameterAttributes attribute in allGenericParameterAttributes)
            {
                if ((genericParameterAttributes & attribute) != GenericParameterAttributes.None)
                {
                    attributes |= attribute;
                }
            }

            genericTypeParameterBuilder.SetGenericParameterAttributes(attributes);
        }
    }
}
