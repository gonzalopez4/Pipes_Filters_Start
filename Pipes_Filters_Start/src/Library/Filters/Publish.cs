using TwitterUCU;

namespace CompAndDel.Filters
{
    public class Publish : IFilter
    {
        /// <summary>
        /// Recibe una imagen, la guarda y la retorna
        /// </summary>
        /// <param name="image">Imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>Imagen con el filtro aplicado</returns>

        public TwitterImage twitterProv;
        public Publish()
        {
            string consumerKey = "CkovShLMNVCY0STsZlcRUFu99";
            string consumerKeySecret = "6rc35cHCyqFQSy4vIIjKiCYu31qqkBBkSS5BRlqeYCt5r7zO5B";
            string accessTokenSecret = "gNytQjJgLvurJekVU0wmBBkrR1Th40sJmTO8JDhiyUkuy";
            string accessToken = "1396065818-MeBf8ybIXA3FpmldORfBMdmrVJLVgijAXJv3B18";
            twitterProv = new TwitterImage(consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
        }
        public IPicture Filter(IPicture image)
        {
            twitterProv.PublishToTwitter("", image.Path);
            return image;
        }
    }
}