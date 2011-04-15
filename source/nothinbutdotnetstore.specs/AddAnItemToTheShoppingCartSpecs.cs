 using Machine.Specifications;
 using developwithpassion.specifications.moq;
using System;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    using developwithpassion.specifications.extensions;

    public class AddAnItemToTheShoppingCartSpecs
    {
        public abstract class concern : Observes<IEncapsulateApplicationSpecificFunctionality,
                                            AddAnItemToTheShoppingCart<object>>
        {
        
        }

        [Subject(typeof(AddAnItemToTheShoppingCart<object>))]
        public class when_run : concern
        {
            Establish c = () =>
                {
                    shopping_cart = depends.on<ICanStoreItems<object>>();

                    the_request = fake.an<IContainRequestDetails>();
                    an_item = fake.an<object>();

                    the_request.setup(x => x.map<object>()).Return(an_item);
                };

            Because b = () => sut.process(the_request);

            It should_add_an_item_to_the_shopping_cart = () => shopping_cart.received(x => x.add(an_item));

            static ICanStoreItems<object> shopping_cart;
            static object an_item;
            static IContainRequestDetails the_request;
        }
    }

    public interface ICanStoreItems<ItemsToStore>
    {
        void add(ItemsToStore an_item);
    }

    public class AddAnItemToTheShoppingCart<ItemsToStore> : IEncapsulateApplicationSpecificFunctionality
    {
        public void process(IContainRequestDetails request)
        {
            throw new NotImplementedException();
        }
    }
}