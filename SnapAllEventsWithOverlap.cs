/**
 * Take a selection of events and make them follow each other removing 
 * any gap between them in the order of the selection
 *
 * Author Romain SIDIDRIS
 **/

using System;
using System.Collections.Generic;
using ScriptPortal.Vegas;

public class EntryPoint
{

    public void FromVegas(Vegas vegas)
    {
        List<VideoEvent> events = new List<VideoEvent>();
        AddSelectedVideoEvents(vegas, events);

		Timecode currentTimecode = Timecode.FromMilliseconds(0);
		Timecode forceLength = Timecode.FromMilliseconds(40);
		Timecode overlapLength = Timecode.FromMilliseconds(40);

        foreach (VideoEvent videoEvent in events)
        {
			Timecode newEnd = currentTimecode + forceLength;
			videoEvent.Start = currentTimecode;
			videoEvent.End = newEnd;
			currentTimecode = currentTimecode + overlapLength;
        }
    }

    void AddSelectedVideoEvents(Vegas vegas, List<VideoEvent> events)
    {
        foreach (Track track in vegas.Project.Tracks)
        {
            if (track.IsVideo())
            {
                foreach (VideoEvent videoEvent in track.Events)
                {
                    if (videoEvent.Selected)
                    {
                        events.Add(videoEvent);
                    }
                }
            }
        }
    }
}


