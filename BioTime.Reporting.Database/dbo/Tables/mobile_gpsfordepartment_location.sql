CREATE TABLE [dbo].[mobile_gpsfordepartment_location] (
    [id]                  INT IDENTITY (1, 1) NOT NULL,
    [gpsfordepartment_id] INT NOT NULL,
    [gpslocation_id]      INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [mobile_gpsfordepartment_location_gpsfordepartment_id_23e9af3a_fk_mobile_gpsfordepartment_id] FOREIGN KEY ([gpsfordepartment_id]) REFERENCES [dbo].[mobile_gpsfordepartment] ([id]),
    CONSTRAINT [mobile_gpsfordepartment_location_gpslocation_id_48b82e9e_fk_mobile_gpslocation_id] FOREIGN KEY ([gpslocation_id]) REFERENCES [dbo].[mobile_gpslocation] ([id])
);


GO
CREATE NONCLUSTERED INDEX [mobile_gpsfordepartment_location_gpsfordepartment_id_23e9af3a]
    ON [dbo].[mobile_gpsfordepartment_location]([gpsfordepartment_id] ASC);


GO
CREATE NONCLUSTERED INDEX [mobile_gpsfordepartment_location_gpslocation_id_48b82e9e]
    ON [dbo].[mobile_gpsfordepartment_location]([gpslocation_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [mobile_gpsfordepartment_location_gpsfordepartment_id_gpslocation_id_58226033_uniq]
    ON [dbo].[mobile_gpsfordepartment_location]([gpsfordepartment_id] ASC, [gpslocation_id] ASC) WHERE ([gpsfordepartment_id] IS NOT NULL AND [gpslocation_id] IS NOT NULL);

