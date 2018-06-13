using TheRacketPlaylistGenerator.Models;
using TheRacketPlaylistGenerator.ViewModels;

namespace TheRacketPlaylistGenerator.Services.Interfaces
{
    interface IPlaylistTransformationService
    {
        PlaylistDetails TransformPlaylistDataEntity(Item dataEntity);
    }
}
