import { FuseNavigation } from "@fuse/types";

export const navigation: FuseNavigation[] = [
    {
        id: "principal",
        title: "",
        type: "group",
        icon: "web",
        children: [
            {
                id: "music",
                title: "Música",
                type: "item",
                icon: "music_note",
                url: "/page/music",
            },
            {
                id: "favorite",
                title: "Playlist",
                type: "item",
                icon: "queue_music",
                url: "/page/favorite",
            }
        ],
    },
];
