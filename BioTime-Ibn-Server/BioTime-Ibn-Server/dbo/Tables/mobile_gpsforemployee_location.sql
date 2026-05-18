CREATE TABLE [dbo].[mobile_gpsforemployee_location] (
    [id]                INT IDENTITY (1, 1) NOT NULL,
    [gpsforemployee_id] INT NOT NULL,
    [gpslocation_id]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [mobile_gpsforemployee_location_gpsforemployee_id_a52023d5_fk_mobile_gpsforemployee_id] FOREIGN KEY ([gpsforemployee_id]) REFERENCES [dbo].[mobile_gpsforemployee] ([id]),
    CONSTRAINT [mobile_gpsforemployee_location_gpslocation_id_497a214f_fk_mobile_gpslocation_id] FOREIGN KEY ([gpslocation_id]) REFERENCES [dbo].[mobile_gpslocation] ([id])
);


GO
CREATE NONCLUSTERED INDEX [mobile_gpsforemployee_location_gpsforemployee_id_a52023d5]
    ON [dbo].[mobile_gpsforemployee_location]([gpsforemployee_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [mobile_gpsforemployee_location_gpsforemployee_id_gpslocation_id_9ceb93bf_uniq]
    ON [dbo].[mobile_gpsforemployee_location]([gpsforemployee_id] ASC, [gpslocation_id] ASC) WHERE ([gpsforemployee_id] IS NOT NULL AND [gpslocation_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [mobile_gpsforemployee_location_gpslocation_id_497a214f]
    ON [dbo].[mobile_gpsforemployee_location]([gpslocation_id] ASC);

