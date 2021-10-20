using FluentAssertions;

using MonoTorrent;
using MonoTorrent.Client;

using System;
using System.Threading.Tasks;

using Xunit;

namespace Torresmo.UnitTests.Features
{
    public class NewTorrentTests
    {
        private static async Task<Torrent> CreateUbuntuTorrent()
        {
            const string ubuntuLink = @"https://releases.ubuntu.com/21.10/ubuntu-21.10-desktop-amd64.iso.torrent";
            var result = await Torrent.LoadAsync(new Uri(ubuntuLink), "./temp");
            return result;
        }

        [Fact]
        public async Task Torrent_LoadFromUri_Works()
        {
            // Arrange

            // Act
            Torrent result = await CreateUbuntuTorrent();

            // Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public async Task TorrentDownload_Works()
        {
            // Arrange
            var torrent = await CreateUbuntuTorrent();
            var client = new ClientEngine();
            
            // Act
            var result = await client.AddAsync(torrent, "./downloads/tempDown");
            await result.StartAsync();
            
            // Assert
            result.Should().NotBeNull();
        }
    }
}
