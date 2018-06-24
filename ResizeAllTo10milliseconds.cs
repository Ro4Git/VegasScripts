/**
 * Take a selection of events and make them follow each other removing 
 * any gap between them in the order of the selection and clamping their duration to ( 0.01 s)
 *
 * Author Romain SIDIDRIS
 * Revision Date: Nov, 20, 2010.
 **/

using System;
using System.Collections.Generic;
using ScriptPortal.Vegas;

public class EntryPoint
{

    public void FromVegas(Vegas vegas)
    {
        foreach (Track track in vegas.Project.Tracks)
        {
			Timecode currentTimecode = Timecode.FromMilliseconds(0);
            foreach (TrackEvent videoEvent in track.Events)
			{
				if (videoEvent.Selected)
                    {
					Timecode newEnd = currentTimecode + Timecode.FromMilliseconds(10);
					videoEvent.Start = currentTimecode;
					videoEvent.End = newEnd;
					currentTimecode = newEnd;
					}
			}
        }
    }

}


