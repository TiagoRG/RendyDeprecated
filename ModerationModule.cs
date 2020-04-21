﻿using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rendy
{
    public class ModerationModule : ModuleBase<SocketCommandContext>
    {
        [Command("prune")]
        [RequireBotPermission(GuildPermission.KickMembers)]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireContext(ContextType.Guild)]
        public async Task Prune(int daysoff = 14)
        {
            await Context.Message.DeleteAsync();
            var totalKicks = await Context.Guild.PruneUsersAsync(daysoff);
            var reply = await Context.Channel.SendMessageAsync($"I kicked {totalKicks} members for being offline for more than {daysoff} days.");
            await Task.Delay(5000);
            await reply.DeleteAsync();
        }

        [Command("kick")]
        [RequireBotPermission(GuildPermission.KickMembers)]
        [RequireUserPermission(GuildPermission.KickMembers)]
        [RequireContext(ContextType.Guild)]
        public async Task Kick(IUser user, [Remainder] string reason = null)
        {
            await Context.Message.DeleteAsync();
            Embed embed = new EmbedBuilder()
                .WithAuthor("Rendy")
                .WithColor(Color.Red)
                .WithTitle(user.Username + "#" + user.Discriminator)
                .WithThumbnailUrl(user.GetAvatarUrl())
                .WithDescription($"This user got kicked from {Context.Guild.Name} so you are able to rejoin. Do you think you are not going to break rules again? Rejoin with the link in field \"Rejoin Invite\"")
                .WithFooter(Const.embedFooter)
                .AddField("Reason", reason)
                .AddField("Moderator", Context.Message.Author, true)
                .AddField("Kicked At", $"{Context.Message.Timestamp.Day}/{Context.Message.Timestamp.Month}/{Context.Message.Timestamp.Year}", true)
                .AddField("Rejoin Invite", "[Click Here](https://discord.gg/3stDnz8)")
                .Build();
            Embed privEmbed = new EmbedBuilder()
                .WithAuthor("Rendy")
                .WithColor(Color.Red)
                .WithTitle(user.Username + "#" + user.Discriminator)
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithDescription($"You got kicked from {Context.Guild.Name}")
                .WithFooter(Const.embedFooter)
                .AddField("Reason", reason)
                .AddField("Moderator", Context.Message.Author, true)
                .AddField("Kicked At", $"{Context.Message.Timestamp.Day}/{Context.Message.Timestamp.Month}/{Context.Message.Timestamp.Year}", true)
                .Build();
            await user.SendMessageAsync(embed: privEmbed);
            await Context.Channel.SendMessageAsync(embed: embed);
            await Context.Guild.GetUser(user.Id).KickAsync(reason);
        }

        [Command("ban")]
        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [RequireContext(ContextType.Guild)]
        public async Task Ban(IUser user, [Remainder] string reason = null)
        {
            await Context.Message.DeleteAsync();
            Embed embed = new EmbedBuilder()
                .WithAuthor("Rendy")
                .WithColor(Color.Red)
                .WithTitle(user.Username + "#" + user.Discriminator)
                .WithThumbnailUrl(user.GetAvatarUrl())
                .WithDescription($"This user got banned from {Context.Guild.Name}")
                .WithFooter(Const.embedFooter)
                .AddField("Reason", reason)
                .AddField("Moderator", Context.Message.Author, true)
                .AddField("Banned At", $"{Context.Message.Timestamp.Day}/{Context.Message.Timestamp.Month}/{Context.Message.Timestamp.Year}", true)
                .Build();
            Embed privEmbed = new EmbedBuilder()
                .WithAuthor("Rendy")
                .WithColor(Color.Red)
                .WithTitle(user.Username + "#" + user.Discriminator)
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithDescription($"You got banned from {Context.Guild.Name}")
                .WithFooter(Const.embedFooter)
                .AddField("Reason", reason)
                .AddField("Moderator", Context.Message.Author, true)
                .AddField("Banned At", $"{Context.Message.Timestamp.Day}/{Context.Message.Timestamp.Month}/{Context.Message.Timestamp.Year}", true)
                .Build();
            await user.SendMessageAsync(embed: privEmbed);
            await Context.Channel.SendMessageAsync(embed: embed);
            await Context.Guild.GetUser(user.Id).BanAsync(7, reason: reason);
        }
        [Command("softban")]
        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        [RequireContext(ContextType.Guild)]
        public async Task SoftBan(IUser user, int days, [Remainder] string reason = null)
        {
            await Context.Message.DeleteAsync();
            Embed embed = new EmbedBuilder()
                .WithAuthor("Rendy")
                .WithColor(Color.Red)
                .WithTitle(user.Username + "#" + user.Discriminator)
                .WithThumbnailUrl(user.GetAvatarUrl())
                .WithDescription($"This user got softbanned from {Context.Guild.Name} to delete their messages.")
                .WithFooter(Const.embedFooter)
                .AddField("Reason", reason)
                .AddField("Moderator", Context.Message.Author, true)
                .AddField("Days Pruned", days, true)
                .AddField("SoftBanned At", $"{Context.Message.Timestamp.Day}/{Context.Message.Timestamp.Month}/{Context.Message.Timestamp.Year}", true)
                .Build();
            Embed privEmbed = new EmbedBuilder()
                .WithAuthor("Rendy")
                .WithColor(Color.Red)
                .WithTitle(user.Username + "#" + user.Discriminator)
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .WithDescription($"You got softbanned from {Context.Guild.Name} to delete your messages so you are able to rejoin the server. Do you think you are not going to break rules again? Rejoin with the link in field \"Rejoin Invite\"")
                .WithFooter(Const.embedFooter)
                .AddField("Reason", reason)
                .AddField("Moderator", Context.Message.Author, true)
                .AddField("Banned At", $"{Context.Message.Timestamp.Day}/{Context.Message.Timestamp.Month}/{Context.Message.Timestamp.Year}", true)
                .AddField("Days Pruned", days, true)
                .AddField("Rejoin Invite", "[Click Here](https://discord.gg/3stDnz8)")
                .Build();
            await user.SendMessageAsync(embed: privEmbed);
            await Context.Channel.SendMessageAsync(embed: embed);
            await Context.Guild.GetUser(user.Id).BanAsync(days, reason: reason);
            await Context.Guild.RemoveBanAsync(user);
        }
    }
}
