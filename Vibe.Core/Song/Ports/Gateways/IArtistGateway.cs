namespace Vibe.Core.Song.Ports.Gateways
{
    public interface IArtistGateway
    {
        /// <summary>
        /// Tente de récuperer l'identifiant d'un interprète par son nom.
        /// </summary>
        /// <param name="name">Le nom cherché</param>
        /// <param name="performerId">l'id de l'interprète.</param>
        /// <returns>Vrai si l'interprète a été trouvé. Faux si l'interprète n'a pas été trouvé.</returns>
        Task<bool> TryGetPerformerIdByName(string name, out Guid performerId);

        /// <summary>
        /// Fournit l'id d'un interprète après l'avoir créé par son nom.
        /// </summary>
        /// <param name="name">Le nom de l'interprète.</param>
        /// <returns>L'identifiant du nouvel interprète.</returns>
        Task<Guid> ProvidePerformerIdByName(string name);
    }
}
