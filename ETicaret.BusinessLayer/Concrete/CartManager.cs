using ETicaret.BusinessLayer.Abstract;
using ETicaret.DataAccessLayer.Abstract;
using ETicaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.BusinessLayer.Concrete
{
    public class CartManager : ICartService
    {
        ICartRepository _cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddToCart(string userId, int productId, int quantity)
        {
            var cart = _cartRepository.GetCartByUserId(userId);

            if (cart != null)
            {
                // Eklemek istediğim ürün Sepette var mı?
                // Eğer ürün sepette yok se Insert/Add/Create işlemi yapmamız gerekiyor.
                // Eğer ürün sepette var ise bu durumda var olan ürünün adedini değiştirmemiz gerekiyor. Bu da Update işlemidir.

                var index = cart.CartItems.FindIndex(x => x.ProductId == productId);
                // ilgili ürünün CartItems'daki indeksini getirecek FindIndex metodu. (FindIndex List'in bir metodu) Index değeri negatif ise ürün listede yok. Bu durumda ürünü eklemem gerekecek. Index değeri negatif değerden farklıysa bu durumda ürünün index numarası gelmiş olcak bu da ürünün listede olduğu anlamına gelir. Burada da update işlemi yapılacak. Var olan quantity'e parametreden gelen değer eklenecek.
                if (index < 0)
                {
                    // create işlemi yapılmalı

                    cart.CartItems.Add(new CartItem()
                    {
                        ProductId = productId,
                        CartId = cart.Id,
                        Quantity = quantity
                    });
                }
                else
                {
                    // update işlemi yapılmalı

                    cart.CartItems[index].Quantity += quantity;
                }

                _cartRepository.Update(cart);

            }
        }

        public void ClearCart(int cartId)
        {
            _cartRepository.ClearCart(cartId);
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart= GetCartByUserId(userId);
            if (cart != null)
            {
                _cartRepository.DeleteFromCart(cart.Id, productId);
            }
        }

        public Cart GetCartByUserId(string userId)
        {
            return _cartRepository.GetCartByUserId(userId);
        }

        public void InitializerCart(string userId)
        {
            _cartRepository.Create(new Cart()
            {
                UserId = userId,
            });
        }
    }
}
