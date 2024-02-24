using Application.Features.AccountAnnouncements.Commands.Create;
using Application.Features.AccountAnnouncements.Commands.Delete;
using Application.Features.AccountAnnouncements.Commands.Update;
using Application.Features.AccountAnnouncements.Queries.GetById;
using Application.Features.AccountAnnouncements.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.AccountAnnouncements.Queries.GetListByAccountId;

namespace Application.Features.AccountAnnouncements.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AccountAnnouncement, CreateAccountAnnouncementCommand>().ReverseMap();
        CreateMap<AccountAnnouncement, CreatedAccountAnnouncementResponse>().ReverseMap();
        CreateMap<AccountAnnouncement, UpdateAccountAnnouncementCommand>().ReverseMap();
        CreateMap<AccountAnnouncement, UpdatedAccountAnnouncementResponse>().ReverseMap();
        CreateMap<AccountAnnouncement, DeleteAccountAnnouncementCommand>().ReverseMap();
        CreateMap<AccountAnnouncement, DeletedAccountAnnouncementResponse>().ReverseMap();
        CreateMap<AccountAnnouncement, GetByIdAccountAnnouncementResponse>().ReverseMap();
        CreateMap<AccountAnnouncement, GetListAccountAnnouncementListItemDto>().ReverseMap();
        CreateMap<AccountAnnouncement, GetListByAccountIdAccountAnnouncementListItemDto>().ReverseMap()
            .ForPath(destinationMember: dest => dest.Announcement.AnnouncementType,
            memberOptions: opt => opt.MapFrom(dto => dto.AnnouncementTypeName))
            .ForPath(destinationMember:dest=>dest.Announcement.Organization.Name,
            memberOptions:opt=>opt.MapFrom(dto=>dto.OrganizationName));
        CreateMap<IPaginate<AccountAnnouncement>, GetListResponse<GetListAccountAnnouncementListItemDto>>().ReverseMap();
        CreateMap<IPaginate<AccountAnnouncement>, GetListResponse<GetListByAccountIdAccountAnnouncementListItemDto>>().ReverseMap();
    }
}