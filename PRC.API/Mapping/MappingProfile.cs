using AutoMapper;
using PRC.API.Resources;
using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRC.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain(base de donnée )  vers Resource
            CreateMap<User, UserResource>();
            CreateMap<Role, RoleResource>();
            //CreateMap<Artist, SaveArtistResource>();
            //CreateMap<Composer, ComposerResourse>();


            // Resources vers Domain ou la base de données

            //CreateMap<MusicResource, Music>();
            //CreateMap<ArtistResource, Artist>();
            //CreateMap<SaveMusicResource, Music>();
            //CreateMap<SaveArtistResource, Artist>();
            //CreateMap<ComposerResourse, Composer>();
            //CreateMap<SaveComposerResource, Composer>();
            CreateMap<UserResource, User>();
            CreateMap<RoleResource, Role>();

        }
    }
}
