﻿using ErsatzTV.Core;

namespace ErsatzTV.Application.Emby;

public record UpdateEmbyPathReplacements(
    int EmbyMediaSourceId,
    List<EmbyPathReplacementItem> PathReplacements) : MediatR.IRequest<Either<BaseError, Unit>>;

public record EmbyPathReplacementItem(int Id, string EmbyPath, string LocalPath);