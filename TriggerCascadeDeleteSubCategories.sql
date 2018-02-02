CREATE TRIGGER [dbo].[Trigger_DeleteSubCategories]
ON [dbo].[Categories]
FOR DELETE
AS
BEGIN
    SET NoCount ON
    DELETE FROM Categories WHERE Category_parent_id IN (SELECT category_id FROM DELETED)
END