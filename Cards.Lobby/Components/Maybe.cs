
namespace Cards.Lobby.Components
{
    public class Maybe<T>
    {
        public T Result { get; private set; }
        public bool IsSuccessful { get; private set; }

        public Maybe(T obj)
        {
            if (obj != null)
            {
                IsSuccessful = true;
                Result = obj;
            }
        }

        public Maybe()
        {
            
        }



        public static implicit operator Maybe<T>(T obj)
        {
            return new Maybe<T>(obj);
        }

    }
}
