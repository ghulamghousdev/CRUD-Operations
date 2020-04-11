import React from 'react';
import { Paper, Typography} from '@material-ui/core';
const VideoDetails = () => {
    if (!video)
    {
        return <div>Loading...</div>
    }
    const videosrc = `http://www.youtube.com/embed/${video.id.videoId}`
    return ( 
            <React.Fragment>
                <Paper elevation={6} style={{height: '70%'}}>
                    <iframe frameBorder="0" height="100%" width="100%" title="video player" src="videosrc"/>
                </Paper>
                <Paper elevation={6}>
                    <typography </typography>
                </Paper>
            </React.Fragment>
        )}

export default VideoDetails;