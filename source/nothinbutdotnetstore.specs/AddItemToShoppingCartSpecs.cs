 using System;
 using Machine.Specifications;
 using developwithpassion.specifications.moq;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;
 using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{   
    public class AddItemToShoppingCartSpecs
    {
        public abstract class concern : Observes<IEncapsulateApplicationSpecificFunctionality,
                                            AddItemToShoppingCart>
        {
        
        }

        [Subject(typeof(AddItemToShoppingCart))]
        public class when_run : concern
        {
            Establish c = () =>
                              {
                                  request_details = fake.an<IContainRequestDetails>();
                                  shopping_cart = depends.on<IContainProducts>();
                                  a_product = fake.an<IContainProductInformation>();

                                  request_details.setup(x => x.map<IContainProductInformation>()).Return(a_product);
                              };


            Because b = () =>
                            sut.process(request_details);

            It should_add_the_item_to_the_shopping_cart = () =>
                                                              shopping_cart.Contains(a_product);

            static IContainRequestDetails request_details;
            static IContainProducts shopping_cart;
            static IContainProductInformation a_product;
        }
    }

    public class AddItemToShoppingCart : IEncapsulateApplicationSpecificFunctionality
    {
        public void process(IContainRequestDetails request)
        {
            throw new NotImplementedException();
        }
    }

    internal interface IContainProducts
    {
        bool Contains(IContainProductInformation aProduct);
    }

    internal interface IContainProductInformation
    {
    }
}
