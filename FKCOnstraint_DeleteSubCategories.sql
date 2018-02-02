ALTER TABLE [Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories] FOREIGN KEY([Category_parent_id])
REFERENCES [Categories] ([category_id])
ON DELETE CASCADE
